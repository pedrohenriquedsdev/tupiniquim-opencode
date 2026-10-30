using RoboTupiniquim.Aplicacao;

var aplicacao = new AplicacaoConsole(new ConsoleEntradaSaida());

return aplicacao.Executar() ? 0 : 1;
