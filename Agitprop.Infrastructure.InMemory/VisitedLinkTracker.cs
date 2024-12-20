﻿using System.Collections.Immutable;
using Agitprop.Core.Interfaces;

namespace Agitprop.Infrastructure.InMemory;

public class VisitedLinkTracker : ILinkTracker
{
    public bool DataCleanupOnStart { get; set; }

    private ImmutableHashSet<string> visitedUrls = ImmutableHashSet.Create<string>();

    public Task AddVisitedLinkAsync(string visitedLink)
    {
        ImmutableInterlocked.Update(ref visitedUrls, set => set.Add(visitedLink));

        return Task.CompletedTask;
    }

    public Task<List<string>> GetVisitedLinksAsync()
    {
        return Task.FromResult(visitedUrls.ToList());
    }

    public Task<List<string>> GetNotVisitedLinks(IEnumerable<string> links)
    {
        return Task.FromResult(links.Except(visitedUrls).ToList());
    }

    public Task<long> GetVisitedLinksCount()
    {
        return Task.FromResult((long)visitedUrls.Count);
    }

    public Task<bool> WasLinkVisited(string link)
    {
        throw new NotImplementedException();
    }

    public Task Initialization => Task.CompletedTask;
}
