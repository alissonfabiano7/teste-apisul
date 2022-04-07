using TesteApisul.Classes;

var elevator = new Elevator();

elevator.checkLowestEquals();

Console.Write("Os andares menos utilizados em ordem são: ");
elevator.andarMenosUtilizado().ForEach(i => Console.Write("{0} ", i));
Console.WriteLine("\n");
Console.Write("Os elevadores mais utilizados em ordem são: ");
elevator.elevadorMaisFrequentado().ForEach(i => Console.Write("{0} ", i));
Console.WriteLine("\n");
Console.Write("Os elevadores menos utilizados em ordem são: ");
elevator.elevadorMenosFrequentado().ForEach(i => Console.Write("{0} ", i));
Console.WriteLine("\n");
Console.Write("Os períodos mais utilizados pelo elevador mais utilizado em ordem são: ");
elevator.periodoMaiorFluxoElevadorMaisFrequentado().ForEach(i => Console.Write("{0} ", i));
Console.WriteLine("\n");
Console.Write("Os períodos menos utilizados pelo elevador menos utilizado em ordem são: ");
elevator.periodoMenorFluxoElevadorMenosFrequentado().ForEach(i => Console.Write("{0} ", i));
Console.WriteLine("\n");
Console.Write("Os períodos mais utilizados em ordem são: ");
elevator.periodoMaiorUtilizacaoConjuntoElevadores().ForEach(i => Console.Write("{0} ", i));
Console.WriteLine("\n");
Console.Write("Os andares menos utilizados em ordem são: ");
Console.WriteLine("O percentual de uso do elevador A é de: " + elevator.percentualDeUsoElevadorA());
Console.WriteLine("O percentual de uso do elevador B é de: " + elevator.percentualDeUsoElevadorB());
Console.WriteLine("O percentual de uso do elevador C é de: " + elevator.percentualDeUsoElevadorC());
Console.WriteLine("O percentual de uso do elevador D é de: " + elevator.percentualDeUsoElevadorD());
Console.WriteLine("O percentual de uso do elevador E é de: " + elevator.percentualDeUsoElevadorE());