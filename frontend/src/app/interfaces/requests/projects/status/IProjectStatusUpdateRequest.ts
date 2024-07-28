export default interface IProjectStatusUpdateRequest {
  projectStatusId: string;
  name: string | null;
  description: string | null;
  nameColor: string;
  backgroundColor: string;
}
