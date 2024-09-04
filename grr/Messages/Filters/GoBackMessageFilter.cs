﻿using grr.History;
using System;

namespace grr.Messages.Filters
{
    public class GoBackMessageFilter : IMessageFilter
    {
        private readonly IHistoryRepository _historyRepository;

        public GoBackMessageFilter(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
        }

        public void Filter(RepositoryFilterOptions filter)
        {
            string filterValue = filter?.RepositoryFilter ?? "";
            if ("-" == filterValue)
            {
                var state = _historyRepository.Load();
                filter.RepositoryFilter = state.LastLocation ?? filterValue;
            }
        }
    }
}
