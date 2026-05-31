#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

public class GooAssetGenerator : EditorWindow
{
    [MenuItem("Tools/Generuj Assety Lepkie")]
    public static void GenerateGooAssets()
    {
        string folderPath = "Assets/GooVisuals";
        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

        // 1. Pocisk (Kropla / Kula)
        CreateBlobTexture($"{folderPath}/Goo_Projectile.png", 64, Color.white, true);
        
        // 2. Rozbryzg / Plama na ziemi (Splat)
        CreateSplatTexture($"{folderPath}/Goo_Splat.png", 128, Color.white);

        AssetDatabase.Refresh();
        Debug.Log("<color=lime>SUKCES!</color> Grafiki kleju/smoły zostały wygenerowane w folderze: Assets/GooVisuals");
    }

    private static void CreateBlobTexture(string path, int size, Color baseColor, bool isDroplet)
    {
        Texture2D tex = new Texture2D(size, size, TextureFormat.RGBA32, false);
        Vector2 center = new Vector2(size / 2f, size / 2f);

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Vector2 pos = new Vector2(x, y);
                if (isDroplet && y > size / 2f) 
                {
                    // Zniekształcenie góry, aby uzyskać kształt kropli
                    float narrow = 1f - ((y - size / 2f) / (size / 2f));
                    pos.x = center.x + (pos.x - center.x) / Mathf.Max(narrow, 0.1f);
                }

                float dist = Vector2.Distance(pos, center);
                float radius = size * 0.35f;

                if (dist < radius)
                {
                    // Antyaliasing i efekt 3D (lekkie cieniowanie)
                    float alpha = Mathf.Clamp01((radius - dist) / 2f);
                    float light = Mathf.Clamp01((radius - dist) / radius);
                    Color finalColor = Color.Lerp(baseColor * 0.6f, Color.white, light * 0.4f);
                    finalColor.a = alpha;
                    tex.SetPixel(x, y, finalColor);
                }
                else
                {
                    tex.SetPixel(x, y, Color.clear);
                }
            }
        }
        SaveTexture(tex, path);
    }

    private static void CreateSplatTexture(string path, int size, Color baseColor)
    {
        Texture2D tex = new Texture2D(size, size, TextureFormat.RGBA32, false);
        Vector2 center = new Vector2(size / 2f, size / 2f);
        float baseRadius = size * 0.25f;

        // Generowanie losowych "wypustek" dla plamy
        int spikes = 8;
        float[] spikeLengths = new float[spikes];
        for (int i = 0; i < spikes; i++) spikeLengths[i] = Random.Range(0.6f, 1.4f);

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Vector2 dir = new Vector2(x, y) - center;
                float dist = dir.magnitude;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                if (angle < 0) angle += 360f;

                // Interpolacja promienia plamy na podstawie kąta
                float spikeIndexFloat = (angle / 360f) * spikes;
                int idxA = Mathf.FloorToInt(spikeIndexFloat) % spikes;
                int idxB = (idxA + 1) % spikes;
                float t = spikeIndexFloat - Mathf.FloorToInt(spikeIndexFloat);
                float currentRadius = baseRadius * Mathf.Lerp(spikeLengths[idxA], spikeLengths[idxB], t);

                if (dist < currentRadius)
                {
                    float alpha = Mathf.Clamp01((currentRadius - dist) / 2f);
                    Color c = baseColor;
                    c.a = alpha;
                    tex.SetPixel(x, y, c);
                }
                else
                {
                    tex.SetPixel(x, y, Color.clear);
                }
            }
        }
        SaveTexture(tex, path);
    }

    private static void SaveTexture(Texture2D tex, string path)
    {
        tex.Apply();
        byte[] bytes = tex.EncodeToPNG();
        File.WriteAllBytes(path, bytes);
        DestroyImmediate(tex);

        // Automatyczne ustawianie typu na Sprite w Unity
        string relativePath = path.Substring(path.IndexOf("Assets"));
        AssetDatabase.ImportAsset(relativePath);
        TextureImporter importer = AssetImporter.GetAtPath(relativePath) as TextureImporter;
        if (importer != null)
        {
            importer.textureType = TextureImporterType.Sprite;
            importer.spritePixelsPerUnit = 100;
            importer.filterMode = FilterMode.Bilinear;
            AssetDatabase.ImportAsset(relativePath, ImportAssetOptions.ForceUpdate);
        }
    }
}
#endif