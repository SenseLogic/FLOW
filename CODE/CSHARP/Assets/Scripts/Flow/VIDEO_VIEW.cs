// -- IMPORTS

using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

// -- TYPES

public class VIDEO_VIEW : VisualElement, IDisposable
{
    // -- ATTRIBUTES

    public GameObject
        ParentGameObject;
    public string
        FilePath;
    public bool
        IsPlayed,
        IsLooping;
    public float
        Width,
        Height,
        AspectRatio;
    public VideoPlayer
        Player_;
    public RenderTexture
        RenderTexture_;
    public Image
        VideoImage;
    public bool
        IsDisposed;

    // -- CONSTRUCTORS

    public VIDEO_VIEW(
        )
    {
        Player_ = null;
        RenderTexture_ = null;
        VideoImage = null;
        IsDisposed = false;

        style.overflow = Overflow.Hidden;
    }

    // -- DESTRUCTOR

    ~VIDEO_VIEW(
        )
    {
        ReleaseResources( false );
    }

    // -- OPERATIONS

    public void SetParentGameObject(
        GameObject parent_game_object
        )
    {
        ParentGameObject = parent_game_object;
    }

    // ~~

    public void SetVideo(
        string file_path,
        bool is_played = false,
        bool is_looping = true,
        int width = 1920,
        int height = 1080
        )
    {
        FilePath = file_path;
        IsPlayed = is_played;
        IsLooping = is_looping;
        Width = width;
        Height = height;
        AspectRatio = Width / Height;

        if ( Player_ == null )
        {
            Player_ = new GameObject( "VideoPlayer" ).AddComponent<VideoPlayer>();
            Player_.transform.SetParent( ParentGameObject.transform );
            Player_.source = VideoSource.Url;
            Player_.url = FilePath;
            Player_.playOnAwake = IsPlayed;
            Player_.isLooping = IsLooping;
            Player_.aspectRatio = VideoAspectRatio.Stretch;

            RenderTexture_ = new RenderTexture( width, height, 24 );
            Player_.targetTexture = RenderTexture_;

            VideoImage = new Image();
            VideoImage.image = RenderTexture_;
            VideoImage.scaleMode = ScaleMode.ScaleAndCrop;
            VideoImage.style.position = Position.Absolute;
            VideoImage.style.left = 0;
            VideoImage.style.right = 0;
            VideoImage.style.top = 0;
            VideoImage.style.bottom = 0;

            Add( VideoImage );
        }
        else
        {
            Player_.source = VideoSource.Url;
        }
    }

    // ~~

    public void Play(
        )
    {
        if ( Player_ != null )
        {
            Player_.Play();
        }
    }

    // ~~

    public void Pause(
        )
    {
        if ( Player_ != null )
        {
            Player_.Pause();
        }
    }

    // ~~

    public void SetTime( double seconds )
    {
        if ( Player_ != null )
        {
            Player_.time = seconds;
        }
    }

    // ~~

    public void Dispose(
        )
    {
        ReleaseResources( true );
        GC.SuppressFinalize( this );
    }

    // ~~

    public void ReleaseResources(
        bool is_disposing
        )
    {
        if ( !IsDisposed )
        {
            if ( is_disposing )
            {
                if ( RenderTexture_ != null )
                {
                    RenderTexture_.Release();
                    RenderTexture_ = null;
                }
            }

            if ( Player_ != null )
            {
                GameObject.Destroy( Player_.gameObject );
                Player_ = null;
            }

            IsDisposed = true;
        }
    }
}
