export default interface IProjectUpdateRequest {
  projectId: string;
  name: string | null;
  description: string | null;
  banner: string | null;
  status: number | null;
}
