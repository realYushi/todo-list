using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using ToDoListAPI.DTOs;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
using ToDoListAPI.Data;
using ToDoListAPI.Controllers;
using ToDoListAPI.Data.Repositories;
using ToDoListAPI.AutoMapper;
using AutoMapper;
using feature_tests.Hooks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace feature_tests.Steps
{
    [Binding]
    public class StepDefinitions
    {
        private readonly TaskController taskController;
        private readonly ListController listController;
        private readonly UserController userController;
        private readonly TaskService taskService;
        private readonly ListService listService;
        private readonly UserService userService;
        private readonly TaskRepository taskRepository;
        private readonly ListRepository listRepository;
        private readonly UserRepository userRepository;
        private readonly UnitOfWork unitOfWork;
        IMapper mapper;
        private readonly ScenarioContext _scenarioContext;
        private HttpClient _httpClient;
        public StepDefinitions(ScenarioContext scenarioContext)
        {
            var context = scenarioContext["DbContext"] as ToDoListContext;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = new Mapper(config);
            taskRepository = new TaskRepository(context);
            listRepository = new ListRepository(context);
            userRepository = new UserRepository(context);
            unitOfWork = new UnitOfWork(context, taskRepository, listRepository, userRepository);
            taskService = new TaskService(unitOfWork, mapper);
            listService = new ListService(unitOfWork, mapper);
            userService = new UserService(unitOfWork, mapper);
            taskController = new TaskController(taskService);
            listController = new ListController(listService);
            userController = new UserController(userService);
            _scenarioContext = scenarioContext;
            _httpClient = DatabaseHooks.HttpClient;
        }


        [Given(@"I am at the task creation screen")]
        public void GivenIAmAtTheTaskCreationScreen()
        {
            Console.WriteLine("Assuming user is at the task creation screen.");
        }
        [When(@"I attempt to add an empty task")]
        public async void WhenIAttemptToAddAnEmptyTask()
        {
            var task = new { };  // Empty payload to simulate user input
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/tasks", task);
            _scenarioContext["response"] = response;  // Store the response for later assertions
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
