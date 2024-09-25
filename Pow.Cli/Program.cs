/*
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

using System.Reflection;

using Pow.Cli.Commands;

using Spectre.Console.Cli;

CommandApp app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<SquareRootCommand>("sqrt")
        .WithAlias("squareroot")
        .WithAlias("square-root");

    config.AddCommand<CubeRootCommand>("cbrt")
        .WithAlias("cuberoot")
        .WithAlias("cube-root");

    config.AddCommand<RootCommand>("root")
        .WithAlias("rt");

    config.AddCommand<PowerCommand>("power")
        .WithAlias("pwr");

    config.UseAssemblyInformationalVersion();
});

return app.Run(args);