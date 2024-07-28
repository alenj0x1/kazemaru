export default interface ITaskCreateRequest {
  name: string;
  projectId: string;
  description: string | null;
  status: number;
}
