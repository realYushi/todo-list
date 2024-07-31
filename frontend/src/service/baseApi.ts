import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"
const apiUrl =
  process.env.REACT_APP_API_URL || "https://todoapi.yushi91.com/api/"

export const baseApi = createApi({
  reducerPath: "baseApi",
  tagTypes: ["Task", "List"],
  baseQuery: fetchBaseQuery({
    baseUrl: apiUrl,
    credentials: "include",
  }),

  endpoints: () => ({}),
})
