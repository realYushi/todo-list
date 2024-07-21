import ITask from "@models/TaskInterface";

import { baseApi } from "@service/baseApi";

export const taskEndpoint = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getTasks: builder.query<ITask[], void>({
      query: () => "task",
    }),
    getTask: builder.query<ITask, string>({
      query: (taskId) => `task/${taskId}`,
    }),
    addTask: builder.mutation<ITask, Partial<ITask>>({
      query: (task) => ({
        url: `task`,
        method: "POST",
        body: task,
      }),
    }),
    updateTask: builder.mutation<ITask, Partial<ITask>>({
      query: (task) => ({
        url: `task/${task.taskId}`,
        method: "PUT",
        body: task,
      }),
    }),
    deleteTask: builder.mutation<void, string>({
      query: (taskId) => ({
        url: `task/${taskId}`,
        method: "DELETE",
      }),
    }),
  }),
  overrideExisting: false,
});
export const {
  useGetTasksQuery,
  useGetTaskQuery,
  useAddTaskMutation,
  useUpdateTaskMutation,
  useDeleteTaskMutation,
} = taskEndpoint;