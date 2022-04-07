using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApisul.Interfaces;

namespace TesteApisul.Classes
{
    public class Elevator : IElevadorService
    {
        public List<ElevatorHelper> _data { get; set; }
        public Elevator()
        {
            this._data = this.loadJson("input.json");
        }

        public List<ElevatorHelper> loadJson(string file)
        {
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                List<ElevatorHelper> items = JsonConvert.DeserializeObject<List<ElevatorHelper>>(json);
                return items;
            }
        }

        public float elevatorUsagePercentage(char elevator)
        {
            double elevatorCount = _data.Where(i => i.elevador == elevator).Count();
            double total = _data.Count;
            return (float)Math.Round(elevatorCount / total * 100, 2);
        }

        public int checkBiggestEquals()
        {
            var i = 0;
            var elevators = _data.GroupBy(i => i.elevador).Select(n => new
            {
                MetricName = n.Key,
                MetricCount = n.Count()
            }).OrderByDescending(n => n.MetricCount).ToList();

            var first = elevators.First().MetricCount;
            
            foreach(var item in elevators)
            {
                if (item.MetricCount == first)
                {
                    i++;
                } else
                {
                    continue;
                }
            }
            return i;
        }

        public int checkLowestEquals()
        {
            var i = 0;
            var elevators = _data.GroupBy(i => i.elevador).Select(n => new
            {
                MetricName = n.Key,
                MetricCount = n.Count()
            }).OrderBy(n => n.MetricCount).ToList();

            var first = elevators.First().MetricCount;

            foreach (var item in elevators)
            {
                if (item.MetricCount == first)
                {
                    i++;
                }
                else
                {
                    continue;
                }
            }
            return i;
        }

        public List<int> andarMenosUtilizado()
        {
            return _data.GroupBy(i => i.andar).OrderBy(grp => grp.Count())
                .Select(grp => grp.Key).ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {
            return _data.GroupBy(i => i.elevador).OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).ToList();
        }

        public List<char> elevadorMenosFrequentado()
        {
            return _data.GroupBy(i => i.elevador).OrderBy(grp => grp.Count())
                .Select(grp => grp.Key).ToList();
        }

        public float percentualDeUsoElevadorA()
        {
            return elevatorUsagePercentage('A');
        }

        public float percentualDeUsoElevadorB()
        {
            return elevatorUsagePercentage('B');
        }

        public float percentualDeUsoElevadorC()
        {
            return elevatorUsagePercentage('C');
        }

        public float percentualDeUsoElevadorD()
        {
            return elevatorUsagePercentage('D');
        }

        public float percentualDeUsoElevadorE()
        {
            return elevatorUsagePercentage('E');
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            return _data.GroupBy(i => i.turno).OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).ToList();
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {   
            var mostUsedElevator = elevadorMaisFrequentado().First();
            var mostUsedElevatorList = _data.Where(i => i.elevador == mostUsedElevator).ToList();
            if (checkBiggestEquals() == 2)
            {
                var secondMostUsedElevator = elevadorMaisFrequentado()[1];
                var mostUsedElevatorList2 = _data.Where(i => i.elevador == secondMostUsedElevator).ToList();
                mostUsedElevatorList.Concat(mostUsedElevatorList2).ToList();
            }
            return mostUsedElevatorList.GroupBy(i => i.turno).OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).ToList();

        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var leastUsedElevator = elevadorMenosFrequentado().First();
            var leastUsedElevatorList = _data.Where(i => i.elevador == leastUsedElevator).ToList();
            if (checkLowestEquals() == 2)
            {
                var secondLeastUsedElevator = elevadorMenosFrequentado()[1];
                var leastUsedElevatorList2 = _data.Where(i => i.elevador == secondLeastUsedElevator).ToList();
                leastUsedElevatorList = leastUsedElevatorList.Concat(leastUsedElevatorList2).ToList();
            }
            return leastUsedElevatorList.GroupBy(i => i.turno).OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).ToList();
        }
    }
}
