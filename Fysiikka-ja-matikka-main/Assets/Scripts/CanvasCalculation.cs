using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CanvasCalculation : MonoBehaviour
{

    public float ScreenWidth = 800;
    public float ScreenHeight = 600;

    [Range(1f,100f)]
    public float WidthPercentage = 75.0f;
    [Range(1f, 100f)]
    public float HeightPercentage = 75.0f;

    private void DrawPopup()
    {
        float width = (WidthPercentage / 100f) * ScreenWidth;
        float height = (HeightPercentage / 100f) * ScreenHeight;
        float x = (ScreenWidth - width) / 2.0f;
        float y = (ScreenHeight - height) / 2.0f;
        DrawXYRectAt(new Vector3(x, y, 0), width, height, Color.red, 4.0f);
    }

    private void DrawScreen()
    {
        DrawXYRectAt(Vector3.zero, ScreenWidth, ScreenHeight, Color.black, 4.0f);
    }
    private void DrawXYRectAt(Vector3 pos, float width, float height, Color c, float thickness = 2.0f)
        {
        Color orig = Handles.color;
            Handles.color = c;
            Vector3 bot_left = pos;
            Vector3 bot_right = pos + new Vector3(width, 0, 0);
            Vector3 top_left = pos + new Vector3(0, height, 0);
            Vector3 top_right = pos + new Vector3(width, height, 0);

            Handles.DrawLine(bot_left, bot_right, thickness);
            Handles.DrawLine(bot_left, top_left, thickness);
            Handles.DrawLine(bot_right, top_right, thickness);
            Handles.DrawLine(top_left, top_right, thickness);
        Handles.color = orig;
        }

    private void OnDrawGizmos()
    {
        DrawScreen();
        DrawPopup();
       // DrawXYRectAt(Vector3.zero, 800, 600, Color.black, 4.0f);
       // DrawXYRectAt(new Vector3(100, 75, 0), 600, 450, Color.red, 4.0f);
    }
}
