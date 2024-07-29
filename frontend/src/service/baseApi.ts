import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"
export const baseApi = createApi({
  reducerPath: "baseApi",
  tagTypes: ["Task", "List"],
  baseQuery: fetchBaseQuery({
    baseUrl: "https://todoapi.yushi91.com/api/",
    credentials: "include",
  }),

  endpoints: () => ({}),
})
