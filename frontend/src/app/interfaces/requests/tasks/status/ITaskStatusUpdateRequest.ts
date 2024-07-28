export default interface ITaskStatusUpdateRequest {
  taskStatusId: string;
  name: string | null;
  description: string | null;
  nameColor: string | null;
  backgroundColor: string | null;
}
