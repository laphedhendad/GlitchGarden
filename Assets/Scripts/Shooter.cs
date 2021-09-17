using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    Transform gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    private void Start()
    {
        gun = gameObject.transform.Find("Body").Find("Gun");
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }
    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }
    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0) return false;
        return true;
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (spawner.transform.position.y - transform.position.y <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
    public void Fire()
    {
        GameObject newProjectile = 
            Instantiate(projectile, gun.position, gun.rotation)
            as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
