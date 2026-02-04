namespace Kazemaru.Shared;

public static class ResponseConstants
{
    // Identify
    public const string UserIdentityNotFound = "The user's identity could not be validated correctly.";
    
    // Note
    public static string NoteNotExists(Guid noteId) => $"The note with id: '{noteId}' does not exist.";
    public const string NoteIdIsRequired = "The note id is a required field";
    public const string NoteCreatedPreviously = "The note was previously created";
    public const string NoteTitleIsLongerThanAllowed = "The note title length is longer than allowed.";

    public const string NoteTaskAndProjectLinkedSameTime =
        "You cannot link a note to a task and a project at the same time.";

    // Project
    public static string ProjectNotExists(Guid projectId) => $"The project with id: '{projectId}' does not exist.";

    public static string ProjectStatusNotExists(int projectStatusId) =>
        $"The project status with ID: '{projectStatusId}' does not exist.";

    public const string ProjectIdIsRequired = "The project id is a required field";
    public const string ProjectCreatedPreviously = "The project was previously created";
    public const string ProjectNameIsLongerThanAllowed = "The project name length is longer than allowed.";
    public const string ProjectLinkedToTasks = "You cannot delete a project that is linked to tasks.";
    public const string ProjectStatusCreatedPreviously = "The project was previously created";
    public const string ProjectStatusNameIsLongerThanAllowed = "The project status name length is longer than allowed.";

    public const string ProjectStatusDescriptionIsLongerThanAllowed =
        "The project status description length is longer than allowed.";

    public const string ProjectStatusNameColorIsLongerThanAllowed =
        "The project status name-color length is longer than allowed.";

    public const string ProjectStatusBackgroundColorIsLongerThanAllowed =
        "The project status background-color length is longer than allowed.";


    // Task
    public static string TaskNotExists(Guid taskId) => $"The task with id: '{taskId}' does not exist.";

    public static string TaskStatusNotExists(int taskStatusId) =>
        $"The task status with ID: '{taskStatusId}' does not exist.";

    public const string TaskIdIsRequired = "The task id is a required field";
    public const string TaskNameIsLongerThanAllowed = "The task name length is longer than allowed.";
    public const string TaskStatusCreatedPreviously = "The task status was previously created";
    public const string TaskStatusNameIsLongerThanAllowed = "The task status name length is longer than allowed.";

    public const string TaskStatusDescriptionIsLongerThanAllowed =
        "The task status description length is longer than allowed.";

    public const string TaskStatusNameColorLongerThanAllowed =
        "The task status name-color length is longer than allowed.";

    public const string TaskStatusBackgroundColorIsLongerThanAllowed =
        "The task status background-color length is longer than allowed.";
}