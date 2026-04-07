export default interface ITaskUpdateRequest {
  taskId: string;
  name: string | null;
  projectId: string | null;
  description: string | null;
  status: number | null;
}
