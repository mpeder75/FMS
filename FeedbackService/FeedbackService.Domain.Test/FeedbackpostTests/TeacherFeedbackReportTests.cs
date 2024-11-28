using FeedbackService.Domain.DomainServices;
using FeedbackService.Domain.Entities;
using FeedbackService.Domain.Test.Fakes;
using Xunit;

namespace FeedbackService.Domain.Test.FeedbackpostTests
{
    public class TeacherFeedbackReportTests
    {
        [Fact]
        public void Given_TeacherWithClasses_WhenRetrievingFeedbackPosts_ThenShouldReturnRelevantFeedbackPosts()
        {
            // Arrange
            var teacher = new FakeTeacher("John", "Doe", "john.doe@example.com");
            var schoolClass = new FakeSchoolClass(1, teacher);
            var room = new Room { Name = "Room 101", Description = "Description of Room 101" };
            var question = new Question { QuestionText = "How was your experience?", AnswerText = "Please provide detailed feedback." };
            var user1 = new FakeUser("Student1", "Last1", "student1@example.com");
            var user2 = new FakeUser("Student2", "Last2", "student2@example.com");
            var feedbackpost1 = Feedbackpost.Create(user1, "Feedback 1", room, question);
            var feedbackpost2 = Feedbackpost.Create(user2, "Feedback 2", room, question);
            room.AddFeedbackpost(feedbackpost1);
            room.AddFeedbackpost(feedbackpost2);
            schoolClass.AddRoom(room);
            teacher.AddClass(schoolClass);
            var reportService = new FeedbackReportService();

            // Act
            var feedbackPosts = reportService.GetFeedbackPosts(teacher);

            // Assert
            Assert.Contains(feedbackpost1, feedbackPosts);
            Assert.Contains(feedbackpost2, feedbackPosts);
        }

        [Fact]
        public void Given_TeacherWithClasses_WhenGeneratingReport_ThenReportShouldContainRelevantFeedbackPosts()
        {
            // Arrange
            var teacher = new FakeTeacher("John", "Doe", "john.doe@example.com");
            var schoolClass = new FakeSchoolClass(1, teacher);
            var room = new Room { Name = "Room 101", Description = "Description of Room 101" };
            var question = new Question { QuestionText = "How was your experience?", AnswerText = "Please provide detailed feedback." };
            var user1 = new FakeUser("Student1", "Last1", "student1@example.com");
            var user2 = new FakeUser("Student2", "Last2", "student2@example.com");
            var feedbackpost1 = Feedbackpost.Create(user1, "Feedback 1", room, question);
            var feedbackpost2 = Feedbackpost.Create(user2, "Feedback 2", room, question);
            room.AddFeedbackpost(feedbackpost1);
            room.AddFeedbackpost(feedbackpost2);
            schoolClass.AddRoom(room);
            teacher.AddClass(schoolClass);
            var reportService = new FeedbackReportService();

            // Act
            var report = reportService.GenerateFeedbackReport(teacher);

            // Assert
            Assert.Contains("Feedback 1", report);
            Assert.Contains("Feedback 2", report);
        }
    }
}

