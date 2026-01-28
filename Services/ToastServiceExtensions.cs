using BlazorBootstrap;

namespace Registro_estudiantil___Tarea_1.Services
{
    public static class ToastServiceExtensions
    {
        public static ToastMessage ShowToast(this ToastService toastService, string title, string customMessage = null)
        {
            var message = new ToastMessage()
            {
                Type = ToastType.Light,
                Title = title,
                Message = customMessage ?? $"A las {DateTime.Now.ToString("hh:mm tt")}"
            };
            toastService.Notify(message);
            return message;
        }

    }
}
