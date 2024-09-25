﻿/*
    EnviousBox - Pow
    Copyright (C) 2024 Alastair Lundy

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, version 3 of the License.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.IO;

using AlastairLundy.Extensions.Collections.IEnumerables;
using AlastairLundy.Extensions.Maths.Powers;

using Pow.Cli.Localizations;

using Spectre.Console;
using Spectre.Console.Cli;

namespace Pow.Cli.Commands;

    public class RootCommand : Command<RootCommand.Settings>
    {

        public class Settings : SharedSettings
        {
            [CommandOption(("--power"))]
            public decimal? RootBy { get; init; }
            
            
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            if (settings.Inputs == null || settings.Inputs.Length == 0 || settings.RootBy == null)
            {
                AnsiConsole.WriteException(new NullReferenceException());
                return -1;
            }

            List<decimal> results = new List<decimal>();

            foreach (decimal input in settings.Inputs)
            {
                decimal root = input.Root((decimal)settings.RootBy!);
            
                results.Add(root);
            }

            if (settings.OutputFile != null)
            {
                try
                {
                    if (!File.Exists(settings.OutputFile))
                    {
                        File.WriteAllLines(settings.OutputFile, results.ToArray().ToStringEnumerable());
                        AnsiConsole.WriteLine($"{Resources.FileSaved_Success} {settings.OutputFile}");
                        return 0;
                    }

                    throw new ArgumentException(Resources.FileSaved_AlreadyExists);
                }
                catch(Exception exception)
                {
                    AnsiConsole.WriteException(exception);
                    return -1;
                }
            }
            // ReSharper disable once RedundantIfElseBlock
            else
            {
                foreach (string result in results.ToStringEnumerable())
                {
                    AnsiConsole.WriteLine(result);
                }

                return 0;
            }
        }
    }