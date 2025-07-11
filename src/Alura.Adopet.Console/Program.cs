﻿using Alura.Adopet.Console.Comandos.Abstracoes;
using Alura.Adopet.Console.Comandos.ComandoFactory;
using Alura.Adopet.Console.UI;
using FluentResults;

IComando? comando = ComandosFactory.CriarComando(args);
if (comando is not null)
{
    var resultado = await comando.ExecutarAsync();
    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
}         
