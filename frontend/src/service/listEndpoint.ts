import IList from "@modelsListInterface"
import { baseApi } from "@service/baseApi"

export const listEndpoint = baseApi.injectEndpoints({
  endpoints: builder => ({
    getLists: builder.query<IList[], void>({
      query: () => "list",
      providesTags: result =>
        result
          ? result.map(list => ({
              type: "List" as const,
              id: list.listId?.toString(),
            }))
          : [{ type: "List", id: "ALL" }],
    }),
    getList: builder.query<IList, string>({
      query: listId => `list/${listId}`,
    }),
    addList: builder.mutation<IList, Partial<IList>>({
      query: list => ({
        url: `list`,
        method: "POST",
        body: list,
      }),
      invalidatesTags: (result, error, list) => [
        { type: "List", id: list.listId?.toString() },
      ],
    }),
    updateList: builder.mutation<IList, Partial<IList>>({
      query: list => ({
        url: `list/${list.listId}`,
        method: "PUT",
        body: list,
      }),
      invalidatesTags: (result, error, list) => [
        { type: "List", id: list.listId?.toString() },
      ],
    }),

    deleteList: builder.mutation<void, string>({
      query: listId => ({
        url: `list/${listId}`,
        method: "DELETE",
      }),
      invalidatesTags: (result, error, listId) => [
        { type: "List", id: listId },
      ],
    }),
  }),
  overrideExisting: false,
})
export const {
  useGetListsQuery,
  useGetListQuery,
  useAddListMutation,
  useUpdateListMutation,
  useDeleteListMutation,
} = listEndpoint
