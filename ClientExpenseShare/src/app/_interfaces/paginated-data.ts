export interface IPaginatedData<T> {
  pageNumber: number;
  totalNumOfPages: number;
  data: T;
}
