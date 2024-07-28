import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"
export const baseApi = createApi({
  reducerPath: "baseApi",
  tagTypes: ["Task", "List"],
  baseQuery: fetchBaseQuery({
    baseUrl:
      "https://todo-be-fea9hthffwd9cwd4.australiaeast-01.azurewebsites.net/api/",
    credentials: "include",
  }),

  endpoints: () => ({}),
})
