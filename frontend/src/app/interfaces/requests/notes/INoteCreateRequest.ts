export default interface INoteCreateRequest {
  title: string;
  content: string;
  projectId: string | null;
  taskId: string | null;
}
