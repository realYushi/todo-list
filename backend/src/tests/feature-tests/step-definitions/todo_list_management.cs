using TechTalk.SpecFlow;

namespace ToDoListTests
{
    [Binding]
    public class ToDoListSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ToDoListSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to the task creation page")]
        public void GivenINavigateToTheTaskCreationPage()
        {
            _scenarioContext.Pending();
        }

        [Given(@"I am at the task creation screen")]
        public void GivenIAmAtTheTaskCreationScreen()
        {
            _scenarioContext.Pending();
        }

        [Given(@"""(.*)"" is listed for editing")]
        [Given(@"""(.*)"" is marked for deletion")]
        [Given(@"""(.*)"" is listed for deletion")]
        [Given(@"""(.*)"" exists in my task list")]
        public void GivenTaskIsListedForAction(string task)
        {
            _scenarioContext.Pending();
        }

        [When(@"I type ""(.*)"" into the task input field")]
        public void WhenITypeIntoTheTaskInputField(string task)
        {
            _scenarioContext.Pending();
        }

        [When(@"I press the ""(.*)"" button")]
        public void WhenIPressTheButton(string button)
        {
            _scenarioContext.Pending();
        }

        [When(@"I attempt to add an empty task")]
        public void WhenIAttemptToAddAnEmptyTask()
        {
            _scenarioContext.Pending();
        }

        [When(@"I edit ""(.*)"" to say ""(.*)""")]
        public void WhenIEditToSay(string originalTask, string updatedTask)
        {
            _scenarioContext.Pending();
        }

        [When(@"I cancel editing the task")]
        public void WhenICancelEditingTheTask()
        {
            _scenarioContext.Pending();
        }

        [When(@"I confirm deletion of ""(.*)""")]
        [When(@"I initiate deletion of ""(.*)""")]
        public void WhenIConfirmDeletionOf(string task)
        {
            _scenarioContext.Pending();
        }

        [When(@"a confirmation dialog asking ""(.*)"" appears")]
        public void WhenAConfirmationDialogAskingAppears(string message)
        {
            _scenarioContext.Pending();
        }

        [When(@"I confirm the deletion")]
        public void WhenIConfirmTheDeletion()
        {
            _scenarioContext.Pending();
        }

        [When(@"I view the main task list page")]
        public void WhenIViewTheMainTaskListPage()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the task ""(.*)"" should appear in the list")]
        [Then(@"the task ""(.*)"" should be removed from my tasks list")]
        [Then(@"the task ""(.*)"" remains unchanged in the list")]
        [Then(@"the task should now list as ""(.*)""")]
        public void ThenTheTaskShouldBeUpdatedAccordingly(string task)
        {
            _scenarioContext.Pending();
        }

        [Then(@"a warning ""(.*)"" should display")]
        public void ThenAWarningShouldDisplay(string message)
        {
            _scenarioContext.Pending();
        }

        [Then(@"I should see ""(.*)"", ""(.*)"", and ""(.*)"" in the list")]
        public void ThenIShouldSeeTasksInTheList(string task1, string task2, string task3)
        {
            _scenarioContext.Pending();
        }
    }
}
