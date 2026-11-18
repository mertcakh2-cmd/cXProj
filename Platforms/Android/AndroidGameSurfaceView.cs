using Android.Content;
using Android.Views;

namespace MyMAUI.Platforms.Android;

public class AndroidGameSurfaceView : SurfaceView
{
    public AndroidGameSurfaceView(Context context)
        : base(context)
    {
        SetBackgroundColor(Android.Graphics.Color.Black);
        Focusable = true;
        FocusableInTouchMode = true;
    }

    public override bool OnTouchEvent(MotionEvent? e)
    {
        if (e == null)
            return false;

        switch (e.Action)
        {
            case MotionEventActions.Down:
                return true;

            case MotionEventActions.Move:
                return true;

            case MotionEventActions.Up:
                return true;
        }

        return base.OnTouchEvent(e);
    }
}
