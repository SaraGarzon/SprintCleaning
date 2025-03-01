using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DevHelper", menuName = "DevHelper")]
public class DevHelper : ScriptableObject
{
    [SerializeField] private bool _reproduceGameplay;
    [SerializeField] private bool _dontOverrideControlsWhenReproduceGameplay;
    [SerializeField] private float _timeScale = 1;
    [field: SerializeField] public bool LogAudioTimeAndPlayerProgressAlongTrack { get; private set; }
    [field: SerializeField] public bool LogUnexpectedTrashCollectionTimings { get; private set; }
    [field: SerializeField] public bool ImmortalPlayer { get; private set; }

    private static DevHelperRef _ref;
    public static DevHelper Instance
    {
        get
        {
            if (_ref == null)
            {
                _ref = FindObjectOfType<DevHelperRef>();
                if (_ref == null)
                {
                    GameObject prefab = Resources.Load<GameObject>("Dev Helper Ref");
                    _ref = Instantiate(prefab).GetComponent<DevHelperRef>();
                }
                _ref.SO.GameplayReproducer = new GameplayReproducer(_ref.SO._reproduceGameplay, _ref.SO._dontOverrideControlsWhenReproduceGameplay);
                if (_ref.SO._timeScale != 1)
                    Time.timeScale = _ref.SO._timeScale;
            }
            return _ref.SO;
        }
    }

    public GameplayReproducer GameplayReproducer { get; private set; }

    public void OnDestroyRef()
    {
        GameplayReproducer.CheckSave();
    }
}
