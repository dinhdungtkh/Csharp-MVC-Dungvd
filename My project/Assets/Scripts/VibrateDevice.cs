using UnityEngine;

public class VibrateDevice : MonoBehaviour
{
    public void TestHandheldFeatures()
    {
        // Rung thiết bị
        Debug.Log("Đang rung thiết bị...");
        Handheld.Vibrate();

        // Phát video toàn màn hình
        string videoPath = "path/to/your/video.mp4";
        bool playbackSuccess = Handheld.PlayFullScreenMovie(videoPath, Color.black, FullScreenMovieControlMode.Full, FullScreenMovieScalingMode.AspectFit);
        Debug.Log("Phát video thành công: " + playbackSuccess);

        // Thiết lập chỉ báo hoạt động
        Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
        Debug.Log("Đã thiết lập kiểu chỉ báo hoạt động");

        // Bắt đầu chỉ báo hoạt động
        Handheld.StartActivityIndicator();
        Debug.Log("Đã bắt đầu chỉ báo hoạt động");

        // Dừng chỉ báo hoạt động sau 5 giây
        Invoke("StopActivityIndicator", 5f);

        // Xóa bộ nhớ cache shader
        Handheld.ClearShaderCache();
        Debug.Log("Đã xóa bộ nhớ cache shader");
    }

    private void StopActivityIndicator()
    {
        Handheld.StopActivityIndicator();
        Debug.Log("Đã dừng chỉ báo hoạt động");
    }
}