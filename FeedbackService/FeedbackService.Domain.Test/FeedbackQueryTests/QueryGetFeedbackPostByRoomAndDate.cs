using FeedbackService.Domain.Test.Fakes;
using FeedbackService.Infrastructure;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Domain.Test.FeedbackQueryTests
{
    public class QueryGetFeedbackPostByRoomAndDate
    {
        // .Where(x => x.RoomId == roomId && x.CreatedAt >= start && x.CreatedAt <= end)
        // ------------------- Testing success scenario, for RoomId ---------------------
        [Fact]
        public async Task Given_RoomId_Have_5_Posts__Then_5_Posts_Are_Expected()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var query = new FakeFeedbackPostQuery(context);
            var roomId = Guid.Parse("11111111-1111-1111-1111-111111111111"); // The RoomId we are searching for.
            // Includes all FakeFeedbackPosts:
            var startDate = new DateOnly(2024, 10, 01); 
            var endDate = new DateOnly(2024, 12, 30); 

            // Act
            var result = await query.TestGetFeedbackPostsByRoomAndDateAsync(roomId, startDate, endDate);

            // Assert
            Assert.Equal(5, result.Count());
        }

        // ------------------- Testing alternative path, for RoomId ---------------------
        [Fact]
        public async Task Given_RoomId_Have_0_Posts__Then_The_Result_Is_Empty()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var query = new FakeFeedbackPostQuery(context);
            var roomId = Guid.Parse("33333333-3333-3333-3333-333333333333"); // This RoomId doesn't exist.
            // Includes all FakeFeedbackPosts:
            var startDate = new DateOnly(2024, 10, 01);
            var endDate = new DateOnly(2024, 12, 30);

            // Act
            var result = await query.TestGetFeedbackPostsByRoomAndDateAsync(roomId, startDate, endDate);

            // Assert
            Assert.Empty(result);
        }

        // ------------------- Testing edge cases for the date window (and roomId) ---------------------
        [Fact]
        public async Task Given_Search_Window_Includes_November__Then__Posts_Are_Expected()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var query = new FakeFeedbackPostQuery(context);
            var roomId = Guid.Parse("11111111-1111-1111-1111-111111111111"); // 5 posts exist with this roomId
            // Includes all FakeFeedbackPosts created in November
            var startDate = new DateOnly(2024, 11, 01);
            var endDate = new DateOnly(2024, 11, 30);

            // Act
            var result = await query.TestGetFeedbackPostsByRoomAndDateAsync(roomId, startDate, endDate); 

            // Assert
            Assert.Equal(3, result.Count());
        }



        // ---------------- Shared setup -------------------------
        private FeedbackContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<FeedbackContext>()
                .UseInMemoryDatabase($"FeedbackTestDb_{Guid.NewGuid()}")
                .Options;

            var context = new FeedbackContext(options);

            context.FeedbackPosts.AddRange(SeedMockData());
            context.SaveChanges();

            return context;
        }

        private static List<FeedbackPost> SeedMockData()
        {
            var mockData = new List<FeedbackPost>
            {
                new FakeFeedbackPost(
                    Guid.Parse("11111111-1111-1111-1111-111111111111"), // The RoomId we are searching for.
                    Guid.NewGuid(),
                    "Post 1",
                    "Some issue",
                    "Some solution",
                    new DateTime(2024, 11, 15, 10, 0, 0) // Within the searched window (Centered).
                ),
                new FakeFeedbackPost(
                    Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Guid.NewGuid(),
                    "Post 2",
                    "Some issue",
                    "Some solution",
                    new DateTime(2024, 11, 1, 10, 0, 0) // Within the searched window (startDate edge case).
                ),
                new FakeFeedbackPost(
                    Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Guid.NewGuid(),
                    "Post 3",
                    "Some issue",
                    "Some solution",
                    new DateTime(2024, 11, 30, 10, 0, 0) // Within the searched window (endDate edge case).
                ),
                new FakeFeedbackPost(
                    Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Guid.NewGuid(),
                    "Post 4",
                    "Some issue",
                    "Some solution",
                    new DateTime(2024, 10, 31, 10, 0, 0) // Outside the searched window (startDate edge case).
                ),
                new FakeFeedbackPost(
                    Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Guid.NewGuid(),
                    "Post 5",
                    "Some issue",
                    "Some solution",
                    new DateTime(2024, 12, 1, 10, 0, 0) // Outside the searched window (endDate edge Case).
                ),
                new FakeFeedbackPost(
                    Guid.Parse("22222222-2222-2222-2222-222222222222"), // NOT The RoomId we are searching for.
                    Guid.NewGuid(),
                    "Post 6",
                    "Some issue",
                    "Some solution",
                    new DateTime(2024, 11, 15, 10, 0, 0) // Within the searched window (Centered), but wrong roomId.
                ),
            };
            return mockData;
        }
    }
}
