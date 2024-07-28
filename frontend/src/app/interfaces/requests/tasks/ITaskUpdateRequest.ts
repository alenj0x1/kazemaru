export default interface ITaskUpdateRequest {
  taskStatusId: string;
  name: string | null;
  projectId: string | null;
  description: string | null;
  status: number | null;
}
