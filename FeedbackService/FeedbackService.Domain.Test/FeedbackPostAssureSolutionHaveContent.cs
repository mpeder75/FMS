
using FeedbackService.Domain.Test.Fakes;

namespace FeedbackService.Domain.Test
{
    public class FeedbackPostAssureSolutionHaveContent
    {
// ------------- Testing success scenario -------------
        [Fact]
        public void Given_Solution_Have_Content__Then_Dont_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = "Some title";
            var issueText = "Valid issue text";
            var solutionText = "Some solution text";
            var createdAt = DateTime.Now;

            // Valid Solution
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            feedbackPost.AssureSolutionHaveContent();
        }

// ------------- Testing alternative paths -------------
        [Fact]
        public void Given_Solution_Is_Whitespace__Then_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = "Some title";
            var issueText = "Valid issue text";
            var solutionText = " ";
            var createdAt = DateTime.Now;

            // Use an empty Solution to trigger the exception
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => feedbackPost.AssureSolutionHaveContent());
            Assert.Equal("Add a solution.", exception.Message);
        }

        [Fact]
        public void Given_Solution_Is_Empty__Then_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = "Some title";
            var issueText = "Valid issue text";
            var solutionText = "";
            var createdAt = DateTime.Now;

            // Use an empty Solution to trigger the exception
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => feedbackPost.AssureSolutionHaveContent());
            Assert.Equal("Add a solution.", exception.Message);
        }


    }
}
