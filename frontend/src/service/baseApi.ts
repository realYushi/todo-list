import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"
const getBaseUrl = () => {
  const { hostname } = window.location
  if (hostname === "localhost") {
    return "https://localhost:5001/api/"
  } else {
    return "https://todoapi.yushi91.com/api/"
  }
}
export const baseApi = createApi({
  reducerPath: "baseApi",
  tagTypes: ["Task", "List"],
  baseQuery: fetchBaseQuery({
    baseUrl: getBaseUrl(),
    credentials: "include",
  }),

  endpoints: () => ({}),
})
