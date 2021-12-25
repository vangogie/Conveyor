using Conveyor.Business.Services.Interfaces;
using Conveyor.ViewModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conveyor.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConveyorCalculateController : ControllerBase
    {
        public readonly IBeltTypesService _beltTypesService;
        public readonly IConveyorBeltsService _conveyorBeltsService;
        public readonly IMetallCostingsService _metallCostingsService;
        public readonly IMotovariosService _motovariosService;
        public readonly ISewsService _sewsService;
        List<double> Pnorm = new List<double>{ 0.06, 0.09, 0.12, 0.18, 0.25, 0.37, 0.55, 0.75, 1.1, 1.5, 2.2, 3.7, 5.5, 7.5, 11, 15, 18.5, 22, 30, 37, 45, 55, 75, 90, 110, 132, 160, 200, 250, 315, 400 }; //нормальный ряд мощностей электродвигателей


        public ConveyorCalculateController(IBeltTypesService beltTypesService, IConveyorBeltsService conveyorBeltsService, IMetallCostingsService metallCostingsService, IMotovariosService motovariosService, ISewsService sewsService)
        {
            _beltTypesService = beltTypesService;
            _conveyorBeltsService = conveyorBeltsService;
            _metallCostingsService = metallCostingsService;
            _motovariosService = motovariosService;
            _sewsService = sewsService;
        }
        [HttpPost]
        public async Task<ConveyorCostAnswer> Post([FromBody] ConveyorDataModel conveyorDataModel)
        {
            ConveyorParams conveyorParams = CalulateEngine(conveyorDataModel);
            double EngineAwerageCost = 0;
            if (conveyorDataModel.Enginetype == "Sew")
            {
                EngineAwerageCost = await _sewsService.AwerageCost(conveyorParams.EnginePower);
            }
            else if (conveyorDataModel.Enginetype == "Motovario")
            {
                EngineAwerageCost = await _motovariosService.AwerageCost(conveyorParams.EnginePower);
            }
            double beltCost = await CalculateBeltCost(conveyorDataModel.Length, conveyorDataModel.Width, conveyorDataModel.BeltType);
            double metallConveyorCost = await CalculateConveyorCost(conveyorDataModel.Length, conveyorDataModel.Width, conveyorDataModel.ConveyorMaterial, conveyorParams.PowerRollerDiameter, conveyorParams.Rollermass);
            double metallFrameCost = 0;
            if (conveyorDataModel.HasFrame)
            {
                metallFrameCost = await CalculateFrameCost(conveyorDataModel.Length, conveyorDataModel.Width, conveyorDataModel.FrameHeight, conveyorDataModel.FrameMaterial);
            }
            ConveyorCostAnswer conveyorCostAnswer = new ConveyorCostAnswer();
            conveyorCostAnswer.TotalCost = (int)(EngineAwerageCost) + (int)(beltCost) + (int)(metallConveyorCost) + (int)(metallFrameCost);
            conveyorCostAnswer.Info =
                $"Составные части стоимости:\n " +
                $"   Мотор-редуктор: ${(int)EngineAwerageCost};\n" +
                $"   Лента: ${(int)beltCost};\n" +
                $"   Металл конвейера: ${(int)metallConveyorCost};\n" +
                $"   Металл рамы: ${(int)metallFrameCost}.\n" +
                $"\n" +
                $"Параметры мотор-редуктора:\n" +
                $"   Мощность: {conveyorParams.EnginePower} (кВт);\n" +
                $"   Обороты выходного вала: {conveyorParams.EngineRpm} (об/мин);\n" +
                $"   Крутящий момент выходного вала: {conveyorParams.EngineMkr} (Нм).\n" +
                $"\n" +
                $"Параметры конвейера:\n" +
                $"   Диаметр приводного вала: {(int)conveyorParams.PowerRollerDiameter} (мм)\n" +
                $"   Длина ленты: {(int)conveyorParams.BeltLength} (мм, бесконечная).";
            return conveyorCostAnswer;
        }

        private ConveyorParams CalulateEngine(ConveyorDataModel data)
        {
            #region Constants
            double Fbelt1percent = 5;   //усилие на ленте при 1% удлинении
            double BeltDelta_T = 2;     //удлинение ленты мм/1000 мм
            double BeltPl = 1.5;        //плотность ленты кг/м2
            double RollerAlpha = 180;   //угол обхвата ролика
            double RollerMass = (data.Length * data.Width) / 150000; //масса ведомых роликов исходя из габаритов конвейера 
            double Kzap = 1.5;          //Коэфициент запаса по тяговому усилию
            double KPD = 0.6;           //КПД мотор-редуктора

            #endregion

            //Расчет
            double mu = CalculateFriction(1, 4);
            double stepen = (mu * (RollerAlpha * 3.14 / 180));
            double T = Math.Pow(2.718, stepen); //тяговый фактор
            double Fnat = data.Width * Fbelt1percent * BeltDelta_T / 10; //Сила натяжения ветви ленты
            double N = 2 * Fnat * RollerAlpha / 180; //Усилие двух ветвей ленты на ведущий ролик в статике (условно)
            double Ssb = N / (1 + T); //Минимальное (полезное) натяжение ленты при сходе с ведущего вала
            double Snb = N - Ssb; //Максимальное (полезное) натяжение ленты на входе в ведущий вал
            double W = Snb - Ssb; //Максимальное тяговое усилие ленты при указанном (полезном) натяжении
            double Dmin = (360 * 2 * Fnat * Kzap) / (RollerAlpha * 3.14 * data.Width * 0.2);//Минимальный диаметр барабана по давлению ленты
            double F = N * mu; //Максимальное тяговое усилие от приводного барабана
            double ml = (data.Width / 1000) * (data.Length / 1000) * 2.5 * BeltPl; //масса ленты
            double Fn = 0.02 * 9.81 * (RollerMass + (ml / 2)) + (0.25 * 9.81 * ((ml / 2) + (data.Mass * Math.Cos(data.Angle * 3.14 / 180))));//тут 0,25 - коэф. трения между подожкой и лентой
            double Fs = 2 * Fn; //Вторичная сила сопротивления
            double Fst = 9.81 * data.Mass * Math.Sin(data.Angle * 3.14 / 180); //Усилие подъема продукта (при Beta > 0)                                                                   
            double Fzh = (data.Width * Fbelt1percent * BeltDelta_T * 0.02 * 4) / 1000;//додумать //Усилие вызванное натяжением ленты (действует на усложнение проворота роликов)
            double Fu = Fn + Fs + Fst + Fzh; //Минимально необходимая тяга//надо добавить учет сопротивления от натяжки ленты
            double P = (Fu * data.Speed) / (0.9 * KPD * 1000);//Необходимая мощность
            double D2min = (Fu * 50 * 180) / (data.Width * RollerAlpha);//Минимальный диаметр приводного ролика
            if (D2min<110)
            {
                D2min = 110;
            }
            double n2 = (data.Speed * 60) / (3.14 * (D2min / 1000));//Обороты приводного вала
            double Mkr = Fu * D2min / 2000;//Крутящий момент на выходном валу
            double J = (BeltDelta_T * data.Length * 2.5) / 1000;//Рекомендуемая возможность регулировки натяжения ленты (с учетом двухкратного запаса)
            double P2 = P * 2; // умножается на 2 для запаса
            int pi = 0; //индекс мощности мотор-редуктора в списке Pnorm
            P2 = Pnorm.FirstOrDefault(x => x > P2);
            //Округление величин
            P2 = Math.Round(P2, 2);//округление до сотых
            n2 = Math.Round(n2, 0);//округление до целых
            Mkr = Math.Round(Mkr, 1);//округление до десятых
            J = Math.Round(J, 0);//округление до целых

            return new ConveyorParams { EngineMkr = Mkr, EnginePower = P2, EngineRpm = n2, PowerRollerDiameter = D2min, Rollermass = RollerMass, BeltLength = data.Length * 2.5 };
        }


        private double CalculateFriction(int Ma, int So)
        {
            //Для резины
            if (Ma == 1 && So == 1) return 0.5;
            if (Ma == 1 && So == 2) return 0.4;
            if (Ma == 1 && So == 3) return 0.25;
            if (Ma == 1 && So == 4) return 0.15;

            //для стальных роликов
            if (Ma == 2 && So == 1) return 0.35;
            if (Ma == 2 && So == 2) return 0.3;
            if (Ma == 2 && So == 3) return 0.2;
            if (Ma == 2 && So == 4) return 0.1;

            return 0.1;
        }

        private async Task<double> CalculateConveyorCost(double length, double width, string materialConveyor, double powerRollerDiameter, double rollermass)
        {
            rollermass *= 1.5;
            double conveyorCarcasMass = length * width / 200000;
            double powerRollerCost = powerRollerDiameter * width * 1.1 / 65;
            double carcasCostKg = await _metallCostingsService.Cost(materialConveyor) * 1.8;
            double rollerCostKg = await _metallCostingsService.Cost("Нержавеющая сталь") * 1.5 * 1.5;
            return (rollermass * rollerCostKg) + (conveyorCarcasMass * carcasCostKg) + powerRollerCost;
        }
        private async Task<double> CalculateFrameCost(double length, double width, double frameHeight, string materialFrame)
        {
            double frameMass = length * Math.Sqrt(width) * frameHeight / 2500000;
            double FrameCostKg = await _metallCostingsService.Cost(materialFrame)*1.5;
            if (materialFrame == "Конструкционная сталь") //тут нужна покраска
            {
                FrameCostKg *= 1.3; //коэф покраски
            }
            return FrameCostKg * frameMass;


        }
        private async Task<double> CalculateBeltCost(double length, double width, string beltType)
        {
            double awerageBeltM2Cost = await _conveyorBeltsService.Cost(beltType);
            double beltSquare = (length/1000) * (width/1000) * 2.5;
            return beltSquare * awerageBeltM2Cost;
        }
    }

    class ConveyorParams
    {
        public double EnginePower { get; set; }
        public double EngineRpm { get; set; }
        public double EngineMkr { get; set; }
        public double Rollermass { get; set; }
        public double PowerRollerDiameter { get; set; }
        public double BeltLength { get; set; }
    }

    public class ConveyorCostAnswer
    {
        public int TotalCost { get; set; }
        public string Info { get; set; }
    }
}
