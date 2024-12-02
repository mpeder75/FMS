using FeedbackService.Domain.Test.Fakes;

namespace FeedbackService.Domain.Test
{
    public class FeedbackPostAssureTitleHaveContent
    {
// ------------- Testing success scenario -------------
        [Fact]
        public void Given_Title_Have_Content__Then_Dont_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = "Valid title";
            var issueText = "Some issue text";
            var solutionText = "Some solution text";
            var createdAt = DateTime.Now;

            // Valid title
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            feedbackPost.AssureTitleHaveContent();
        }
        
// ------------- Testing alternative paths -------------
        [Fact]
        public void Given_Title_Is_Whitespace__Then_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = " ";
            var issueText = "Some issue text";
            var solutionText = "Some solution text";
            var createdAt = DateTime.Now;

            // Use an empty title to trigger the exception
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => feedbackPost.AssureTitleHaveContent());
            Assert.Equal("Add a Title.", exception.Message);
        }

        [Fact]
        public void Given_Title_Is_Empty__Then_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = "";
            var issueText = "Some issue text";
            var solutionText = "Some solution text";
            var createdAt = DateTime.Now;

            // Use an empty title to trigger the exception
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => feedbackPost.AssureTitleHaveContent());
            Assert.Equal("Add a Title.", exception.Message);
        }
    }
}
