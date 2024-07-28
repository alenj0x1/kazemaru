export default interface IProjectUpdateRequest {
  projectId: string;
  name: string | null;
  description: string | null;
  status: number | null;
}
