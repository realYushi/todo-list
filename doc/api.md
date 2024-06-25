# entities

Tasks: Individual to-dos.
Lists: Collections of tasks.
Users: If the app supports multiple users.

# attributes

tasks: id, title, description, due_date, status, priority, list_id
lists: id, name, user_id, description
users: id, username, email, password

# endpoint

Tasks
GET /tasks - Retrieve all tasks
GET /tasks/{id} - Retrieve a specific task by ID
POST /tasks - Create a new task
PUT /tasks/{id} - Update an existing task
DELETE /tasks/{id} - Delete a task

Lists
GET /lists - Retrieve all lists
GET /lists/{id} - Retrieve a specific list by ID
POST /lists - Create a new list
PUT /lists/{id} - Update an existing list
DELETE /lists/{id} - Delete a list

Users
GET /users - Retrieve all users
GET /users/{id} - Retrieve a specific user by ID
POST /users - Create a new user
PUT /users/{id} - Update an existing user
DELETE /users/{id} - Delete a user
