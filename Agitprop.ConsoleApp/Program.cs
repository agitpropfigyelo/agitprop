﻿using NewsArticleScraper.Core;
using NewsArticleScraper.Scrapers;
using WebReaper.Builders;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        DateTime date = new(2024, 03, 11);
        // var engine = await new ScraperEngineBuilder()
        //     .GetWithBrowser("https://444.hu/2024/03/11")
        //     .Parse(new()
        //     {
        // new("idk", ".text-3xl.font-bold"),
        //     })
        //     .WriteToJsonFile("output.json")
        //     .PageCrawlLimit(10)
        //     .WithParallelismDegree(30)
        //     .LogToConsole()
        //     .BuildAsync();

        // await engine.RunAsync();

        
    }
}