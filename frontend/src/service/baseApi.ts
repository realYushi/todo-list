import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"
export const baseApi = createApi({
  reducerPath: "baseApi",
  tagTypes: ["Task", "List"],
  baseQuery: fetchBaseQuery({
    baseUrl: "https://localhost:5001/api/",
    credentials: "include",
  }),

  endpoints: () => ({}),
})
