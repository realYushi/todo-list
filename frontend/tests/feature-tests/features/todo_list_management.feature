Feature: To-Do List Management
  As a user, I want to manage my tasks using CRUD operations so that I can keep track of what I need to do.

  Scenario: Successfully add a new task
    Given I am on the task creation page
    When I enter "Buy groceries" into the task input field
    And I click the 'Add Task' button
    Then "Buy groceries" should be added to my tasks list

  Scenario: Attempt to add an empty task
    Given I am on the task creation page
    When I click the 'Add Task' button without entering any text
    Then I should see a warning message "Task cannot be empty"

  Scenario: Successfully edit a task
    Given "Buy groceries" is an existing task in my list
    When I click on the 'Edit' button next to "Buy groceries"
    And I change the task text to "Buy groceries and bread"
    And I click the 'Save' button
    Then the task should update to "Buy groceries and bread" in my tasks list

  Scenario: Cancel editing a task
    Given "Buy groceries" is an existing task in my list
    When I click on the 'Edit' button next to "Buy groceries"
    And I change the task text to "Buy groceries and bread"
    And I click the 'Cancel' button
    Then the task should still read "Buy groceries" in my tasks list

  Scenario: Successfully delete a task
    Given "Buy groceries" is an existing task in my list
    When I click the 'Delete' button next to "Buy groceries"
    Then "Buy groceries" should be removed from my tasks list

  Scenario: Confirm before deleting a task
    Given "Buy groceries" is an existing task in my list
    When I click the 'Delete' button next to "Buy groceries"
    And a confirmation dialog appears asking "Are you sure?"
    And I click 'Yes'
    Then "Buy groceries" should be removed from my tasks list

  Scenario: View tasks in a list
    Given I have added the tasks "Buy groceries", "Call mom", and "Pay bills" to my list
    When I navigate to the main page of the To-Do List app
    Then I should see all tasks listed as "Buy groceries", "Call mom", and "Pay bills"
