using System;
using UnityEngine;

public class DelegatesManager : MonoBehaviour
{

    //! Değer döndürmeyen metotlar için Action kullanılır
    private Action empytAction;
    private Action<float, int> floatIntAction;


    //!Değer döndüren/döndürmeyen metotlar için Func kullanılır
    private Func<int> voidFunc;
    private Func<float, bool> returnFunc;


    void Start()
    {
        empytAction = () =>
        {
            Debug.Log("Empty action delegate is start");
        };

        floatIntAction = (float f, int i) =>
        {
            Debug.Log($"Float value: {f}, int value:  {i}");
        };


        empytAction();
        floatIntAction(2.22f, 24);


        voidFunc = () => 5;


        returnFunc = (float f) =>
        {
            Debug.Log(f);
            return f < 5;
        };
    }
}
