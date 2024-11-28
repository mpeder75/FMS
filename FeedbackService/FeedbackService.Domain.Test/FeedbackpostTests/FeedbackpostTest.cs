using FeedbackService.Domain.Entities;
using FeedbackService.Domain.Test.Fakes;

namespace FeedbackService.Domain.Test.FeedbackpostTests;

// Vi bruger BDD naming style som Kaj med: Given_When_Then

public class FeedbackpostTest
{
    [Fact]
    public void Given_ValidInputs_WhenCreatingFeedbackpost_ThenAuthorShouldBeAnonymized()
    {
        // Arrange
        var user = new FakeUser("John", "Doe", "john.doe@example.com");
        var room = new Room { Name = "Room 101", Description = "Description of Room 101" };
        var question = new Question
        { QuestionText = "How was your experience?", AnswerText = "Please provide detailed feedback." };
        var title = "Feedback Title";

        // Act
        var feedbackpost = Feedbackpost.Create(user, title, room, question);

        // Assert
        Assert.Null(feedbackpost.Author);
        Assert.Equal(title, feedbackpost.Title);
        Assert.Equal(room, feedbackpost.Room);
        Assert.Equal(question, feedbackpost.Feedback);
        Assert.Equal(0, feedbackpost.Likes);
        Assert.Equal(0, feedbackpost.Dislikes);
        Assert.NotEqual(default, feedbackpost.CreatedAt);
    }

    [Fact]
    public void Given_FeedbackpostWithZeroLikes_WhenIncrementingLikes_ThenLikesShouldIncreaseByOne()
    {
        // Arrange

        var user = new FakeUser("Homer", "Simpson", " ChunkyLover53@aol.com");
        var room = new Room { Name = "Tv Room", Description = "Place Homer lives" };
        var question = new Question { QuestionText = "What is Homers favorite word?", AnswerText = "Doh" };
        var title = "Homer's Feedback";
        var feedbackpost = new FakeFeedbackpost(user, title, room, question);

        // Act
        feedbackpost.IncrementLikes();

        // Assert
        Assert.Equal(1, feedbackpost.Likes);
    }

    [Fact]
    public void Given_ValidFeedbackpost_WhenAddingComment_ThenCommentCountShouldIncrease()
    {
        // Arrange
        var user = new FakeUser("Marge", "Simpson", "marge@aol.com");
        var room = new Room { Name = "Kitchen", Description = "Place where Simpsons eats" };
        var question = new Question
        { QuestionText = "What is Marge's favorite food?", AnswerText = "Buttered noodles" };
        var title = "Marge's Feedback";
        var feedbackpost = new FakeFeedbackpost(user, title, room, question);

        // Act
        feedbackpost.AddComment("Im more into pizza");

        // Assert
        Assert.Single(feedbackpost.Comments);
        Assert.Equal("Im more into pizza", feedbackpost.Comments.First().CommentString);
    }

    [Fact]
    public void Given_ValidFeedbackpost_WhenAnonymize_ThenAuthorShouldBeNull()
    {
        // Arrange
        var user = new FakeUser("John", "Doe", "john.doe@example.com");
        var room = new Room { Name = "Room 101", Description = "Description of Room 101" };
        var question = new Question
        { QuestionText = "How was your experience?", AnswerText = "Please provide detailed feedback." };
        var title = "Feedback Title";
        var feedbackpost = new FakeFeedbackpost(user, title, room, question);

        // Act
        feedbackpost.Anonymize();

        // Assert
        Assert.Null(feedbackpost.Author);
    }
}

