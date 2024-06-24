Feature: To-Do List Management
  As a user, I want to manage my tasks using CRUD operations so that I can keep track of what I need to do.

  Scenario: Successfully add a new task
    Given I navigate to the task creation page
    When I type "Buy groceries" into the task input field
    And I press the "Add Task" button
    Then the task "Buy groceries" should appear in the list

  Scenario: Attempt to add an empty task
    Given I am at the task creation screen
    When I attempt to add an empty task
    Then a warning "Task cannot be empty" should display

  Scenario: Successfully edit a task
    Given "Buy groceries" exists in my task list
    When I edit "Buy groceries" to say "Buy groceries and bread"
    Then the task should now list as "Buy groceries and bread"

  Scenario: Cancel editing a task
    Given "Buy groceries" is listed for editing
    When I cancel editing the task
    Then the task "Buy groceries" remains unchanged in the list

  Scenario: Successfully delete a task
    Given "Buy groceries" is listed for deletion
    When I confirm deletion of "Buy groceries"
    Then "Buy groceries" should be removed from my tasks list

  Scenario: Confirm before deleting a task
    Given "Buy groceries" is marked for deletion
    When I initiate deletion of "Buy groceries"
    And a confirmation dialog asking "Are you sure?" appears
    And I confirm the deletion
    Then "Buy groceries" should be removed from my tasks list

  Scenario: View tasks in a list
    Given I have added the tasks "Buy groceries", "Call mom", and "Pay bills" to my list
    When I view the main task list page
    Then I should see "Buy groceries", "Call mom", and "Pay bills" in the list
