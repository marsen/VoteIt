﻿using System.Collections.Generic;
using System.Linq;
using VoteIt.Models;

namespace VoteIt.Repositories
{
    public class FeedRepository
    {
        private VoteItDBContext _context;

        public FeedRepository(VoteItDBContext context)
        {
            this._context = context;
        }

        public void UpdateLike(int feedId)
        {
            var feed = this._context.Feed.Where(i => i.FeedId == feedId).FirstOrDefault();
            feed.FeedLike++;
            this._context.SaveChanges();
        }

        public void CreateFeedLike(FeedLike feedLike)
        {
            this._context.FeedLike.Add(feedLike);
            this._context.SaveChanges();
        }

        public bool IsLike(long feedId, string user)
        {
            var isLike = this._context.FeedLike.Any(i => i.FeedLikeFeedId == feedId
            && i.FeedLikeCreatedUser == user
            && i.FeedLikeValidFlag == true);

            return isLike;
        }

        public List<Feed> GetFeedList()
        {
            var list = this._context.Feed.ToList(); ;
            return list;
        }

        public void CreateFeed(Feed feed)
        {
            this._context.Add(feed);
            this._context.SaveChangesAsync();
        }

        /// <summary>
        /// 由 FeedLike 統計 Like 數
        /// </summary>
        /// <returns></returns>
        public List<Feed> GetFeedListWithFeedLike()
        {
            var feedLikeCount = this._context.FeedLike.GroupBy(fl => fl.FeedLikeFeedId)
                .Select(fl => new
                {
                    FeedLike_FeedId = fl.Key,
                    FeedLike_Count = fl.Count()
                });

            var feedList = this._context.Feed.GroupJoin(feedLikeCount,
            f => f.FeedId,
            l => l.FeedLike_FeedId,
            (f, flc) => new Feed
            {
                FeedId = f.FeedId,
                FeedTitle = f.FeedTitle,
                FeedCreatedDateTime = f.FeedCreatedDateTime,
                FeedCreatedUser = f.FeedCreatedUser,
                FeedLike = flc.Count() > 0 ? flc.First().FeedLike_Count : 0
            }).ToList();

            return feedList;
        }
    }
}