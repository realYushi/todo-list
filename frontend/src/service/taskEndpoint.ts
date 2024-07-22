import ITask from "@models/TaskInterface"

import { baseApi } from "@service/baseApi"

export const taskEndpoint = baseApi.injectEndpoints({
  endpoints: builder => ({
    getTasks: builder.query<ITask[], void>({
      query: () => "task",
      providesTags: result =>
        result
          ? [
              ...result.map(task => ({
                type: "Task" as const,
                id: task.taskId?.toString(),
              })),
              { type: "Task", id: "LIST" },
            ]
          : [{ type: "Task", id: "LIST" }],
    }),
    getTask: builder.query<ITask, string>({
      query: taskId => `task/${taskId}`,
    }),
    addTask: builder.mutation<ITask, Partial<ITask>>({
      query: task => ({
        url: `task`,
        method: "POST",
        body: task,
      }),
      invalidatesTags: [{ type: "Task", id: "LIST" }, "Task"],
    }),
    updateTask: builder.mutation<ITask, Partial<ITask>>({
      query: task => ({
        url: `task/${task.taskId}`,
        method: "PUT",
        body: task,
      }),
      invalidatesTags: (result, error, task) => [
        { type: "Task", id: task.taskId?.toString() },
      ],
    }),
    deleteTask: builder.mutation<void, string>({
      query: taskId => ({
        url: `task/${taskId}`,
        method: "DELETE",
      }),
      invalidatesTags: (result, error, taskId) => [
        { type: "Task", id: taskId.toString() },
      ],
    }),
  }),
  overrideExisting: false,
})
export const {
  useGetTasksQuery,
  useGetTaskQuery,
  useAddTaskMutation,
  useUpdateTaskMutation,
  useDeleteTaskMutation,
} = taskEndpoint
