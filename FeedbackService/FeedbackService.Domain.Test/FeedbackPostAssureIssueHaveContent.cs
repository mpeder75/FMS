
using FeedbackService.Domain.Test.Fakes;

namespace FeedbackService.Domain.Test
{
    public class FeedbackPostAssureIssueHaveContent
    {
// ------------- Testing success scenario -------------
        [Fact] 
        public void Given_Issue_Have_Content__Then_Dont_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = "Some title";
            var issueText = "Valid issue text";
            var solutionText = "Some solution text";
            var createdAt = DateTime.Now;

            // Valid Issue
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            feedbackPost.AssureIssueHaveContent();
        }

// ------------- Testing alternative paths -------------
        [Fact] 
        public void Given_Issue_Is_Whitespace__Then_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = "Some title";
            var issueText = " ";
            var solutionText = "Some solution text";
            var createdAt = DateTime.Now;

            // Use an empty Issue to trigger the exception
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => feedbackPost.AssureIssueHaveContent());
            Assert.Equal("Describe an issue.", exception.Message);
        }

        [Fact]
        public void Given_Issue_Is_Empty__Then_Throw_Exception()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var authorId = Guid.NewGuid();
            var title = "Some title";
            var issueText = "";
            var solutionText = "Some solution text";
            var createdAt = DateTime.Now;

            // Use an empty Issue to trigger the exception
            var feedbackPost = new FakeFeedbackPost(roomId, authorId, title, issueText, solutionText, createdAt);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => feedbackPost.AssureIssueHaveContent());
            Assert.Equal("Describe an issue.", exception.Message);
        }
    }
}
