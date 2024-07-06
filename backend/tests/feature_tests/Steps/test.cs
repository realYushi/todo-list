
using TechTalk.SpecFlow;


namespace feature_tests.Steps
{
    [Binding]
    public class StepDefinitions
    {

        public StepDefinitions(ScenarioContext scenarioContext)
        {
        }


        [Given(@"I am at the task creation screen")]
        public void GivenIAmAtTheTaskCreationScreen()
        {
            // Implement the step definition here
        }
        [When(@"I attempt to add an empty task")]
        public async void WhenIAttemptToAddAnEmptyTask()
        {
            // Implement the step definition here
        }


        [Then(@"a warning ""(.*)"" should display")]
        public void ThenAWarningShouldDisplay(string warningMessage)
        {
            // Implement the step definition here
        }

        [Given(@"""(.*)"" is listed for editing")]
        public void GivenIsListedForEditing(string taskName)
        {
            // Implement the step definition here
        }

        [When(@"I cancel editing the task")]
        public void WhenICancelEditingTheTask()
        {
            // Implement the step definition here
        }

        [Then(@"the task ""(.*)"" remains unchanged in the list")]
        public void ThenTheTaskRemainsUnchangedInTheList(string taskName)
        {
            // Implement the step definition here
        }

        [Given(@"""(.*)"" is marked for deletion")]
        public void GivenIsMarkedForDeletion(string taskName)
        {
            // Implement the step definition here
        }

        [When(@"I initiate deletion of ""(.*)""")]
        public void WhenIInitiateDeletionOf(string taskName)
        {
            // Implement the step definition here
        }

        [When(@"a confirmation dialog asking ""(.*)"" appears")]
        public void WhenAConfirmationDialogAskingAppears(string confirmationMessage)
        {
            // Implement the step definition here
        }

        [When(@"I confirm the deletion")]
        public void WhenIConfirmTheDeletion()
        {
            // Implement the step definition here
        }

        [Then(@"""(.*)"" should be removed from my tasks list")]
        public void ThenShouldBeRemovedFromMyTasksList(string taskName)
        {
            // Implement the step definition here
        }

        [Given(@"I navigate to the task creation page")]
        public void GivenINavigateToTheTaskCreationPage()
        {
            // Implement the step definition here
        }

        [When(@"I type ""(.*)"" into the task input field")]
        public void WhenITypeIntoTheTaskInputField(string taskName)
        {
            // Implement the step definition here
        }

        [When(@"I press the ""(.*)"" button")]
        public void WhenIPressTheButton(string buttonName)
        {
            // Implement the step definition here
        }

        [Then(@"the task ""(.*)"" should appear in the list")]
        public void ThenTheTaskShouldAppearInTheList(string taskName)
        {
            // Implement the step definition here
        }

        [Given(@"""(.*)"" exists in my task list")]
        public void GivenExistsInMyTaskList(string taskName)
        {
            // Implement the step definition here
        }

        [When(@"I edit ""(.*)"" to say ""(.*)""")]
        public void WhenIEditToSay(string oldTaskName, string newTaskName)
        {
            // Implement the step definition here
        }

        [Then(@"the task should now list as ""(.*)""")]
        public void ThenTheTaskShouldNowListAs(string newTaskName)
        {
            // Implement the step definition here
        }

        [Given(@"I have added the tasks ""(.*)"", ""(.*)"", and ""(.*)"" to my list")]
        public void GivenIHaveAddedTheTasksAndToMyList(string task1, string task2, string task3)
        {
            // Implement the step definition here
        }

        [When(@"I view the main task list page")]
        public void WhenIViewTheMainTaskListPage()
        {
            // Implement the step definition here
        }

        [Then(@"I should see ""(.*)"", ""(.*)"", and ""(.*)"" in the list")]
        public void ThenIShouldSeeAndInTheList(string task1, string task2, string task3)
        {
            // Implement the step definition here
        }
    }
}
