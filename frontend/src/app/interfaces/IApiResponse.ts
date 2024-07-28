export default interface IApiResponse<T> {
  message: string;
  isSuccess: boolean;
  data: T;
  reqDate: string;
}