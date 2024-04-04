﻿using HtmlAgilityPack;
using NewsArticleScraper.Core;

namespace NewsArticleScraper.Scrapers;

public class TelexScraper : INewsSiteScraper
{
    public string GetArticleContent(HtmlDocument document)
    {
        // Select nodes with class "article-title"
        var titleNode = document.DocumentNode.SelectSingleNode("//div[@class='title-section__top']");
        string titleText = titleNode.InnerText.Trim() + " ";

        var articleNode = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'article-html-content')]");
        string articleText = articleNode.InnerText.Trim() + " ";

        // Concatenate all text
        string concatenatedText = titleText + articleText;

        return Helper.CleanUpText(concatenatedText);
    }

    public Task<List<string>> GetArticlesForDateAsync(DateTime dateIn)
    {
        throw new NotImplementedException();
    }
}