using UnityEngine;

public class sT : MonoBehaviour
{
    public GameObject player;
    float SP = 1f; float SPOV = 2f;
    public Transform LB;              public Transform RRoundBr;
    public Transform RB;              public Transform LRoundBr;
    public Transform LlB;
    public Transform RlB;             public bool spawmNow;
    public GameObject Lbranch;        public bool LeftSpawmed;
    public GameObject Rbranch;        public bool RightSpawmed;
    public GameObject LleaveBranch;   public GameObject roundLbranch;
    public GameObject RleaveBranch;   public GameObject roundRbranch;
    public GameObject Tree;           public Transform treePos;
    public GameObject[] BRANCH;

    void Start()
    {
        SpawmFirstBranch();
        repeatSpawm();
    }

    void Update()
    {

        if ((LB.transform.position.y - player.transform.position.y) < 100f)
            repeatSpawm();

    }
    private void LateUpdate()
    {
        if ((LB.transform.position.y - player.transform.position.y) < 100f)
            repeatSpawm();
    }

    void repeatSpawm()
    {
        for (int i = 0; i <= 50; i++)
        {
            Spawm();
        }
        for(int i = 0; i < 8; i++)
        {
            spawmNextTree();
        }
    }

    void spawmNextTree()
    {
        Vector3 growTree = treePos.transform.position;
        growTree.y += 13.25f;
        growTree.x = 0;
        treePos.transform.position = growTree;
        Instantiate(Tree, treePos.transform.position, treePos.transform.rotation);
    }


    //start spawm randomly
    void Spawm()
    {
        int random = Random.Range(1, 10);
        if (random >= 3)
        {
            spawmOpposite();
        }
        else if (random <= 3)
        {
            spawmOver();
        }
    }

    //func
    void spawmOpposite()
    {
        Vector3 LBSP = LB.transform.position;
        Vector3 LLBSP = LlB.transform.position;
        Vector3 RBSP = RB.transform.position;
        Vector3 RLBSP = RlB.transform.position;
        if (LeftSpawmed)
        {
            RBSP.y = LBSP.y;
            float h = Random.Range(0.2f, 1f);
            RBSP.y += (SP + h);
            RLBSP.y = RBSP.y;
            RB.transform.position = RBSP;
            RlB.transform.position = RLBSP;
            int rd = Random.Range(1, 3);
            if(rd > 1)
            {
                spawmRbr();
            }else if(rd < 2)
            {
                spawmRleaveBr();
            }
        }else if (RightSpawmed)
        {
            LBSP.y = RBSP.y;
            float h1 = Random.Range(0.2f, 1f);
            LBSP.y += (SP + h1);
            LLBSP.y = LBSP.y;
            LB.transform.position = LBSP;
            LlB.transform.position = LLBSP;
            int rD = Random.Range(1, 3);
            if(rD > 1)
            {
                spawmLbr();
            }else if(rD < 2)
            {
                spawmLleaveBr();
            }
        }
    }
    void spawmOver()
    {
        spawmUpperBr();
        spawmRoundBr();
    }
    void SpawmFirstBranch()
    {
        int rd = Random.Range(1, 3);
        if(rd > 1)
        {
            spawmBRANCH();
        }else if(rd < 2)
        {
            spawmLEAVEBr();
        }
    }

    //core code
    void spawmBRANCH()
    {
        int b = Random.Range(1, 3);
        if (b > 1)
        {
            spawmLbr();
        }
        else if (b < 2)
            {
                spawmRbr();
            }
    }
    void spawmLbr()
    {
        Instantiate(Lbranch, LB.position, LB.rotation);
        LeftSpawmed = true;
        RightSpawmed = false;
    }
    void spawmRbr()
    {
        Instantiate(Rbranch, RB.position, RB.rotation);
        RightSpawmed = true;
        LeftSpawmed = false;
    }

    void spawmLEAVEBr()
    {
        int l = Random.Range(1, 3);
        if (l > 1)
        {
            spawmLleaveBr();
        }
        else if (l < 2)
            {
                spawmRleaveBr();
            }
    }
    void spawmLleaveBr()
    {
        Instantiate(LleaveBranch, LlB.position, LlB.rotation);
        LeftSpawmed = true;
        RightSpawmed = false;
    }
    void spawmRleaveBr()
    {
        Instantiate(RleaveBranch, RlB.position, RlB.rotation);
        RightSpawmed = true;
        LeftSpawmed = false;
    }

    void spawmUpperBr()
    {
        Vector3 LBOV = LB.transform.position;
        Vector3 RBOV = RB.transform.position;
        Vector3 LLBOV = LlB.transform.position;
        Vector3 RLBOV = RlB.transform.position;
        if (LeftSpawmed)
        {
            float h = Random.Range(1f, 2f);
            LBOV.y += (SPOV + h);
            LLBOV.y = LBOV.y;
            LB.transform.position = LBOV;
            LlB.transform.position = LLBOV;
            int Rd = Random.Range(1, 3);
            if (Rd < 2)
            {
                spawmLbr();
            }
            else if (Rd > 1)
            {
                spawmLleaveBr();
            }
        }
        else if (RightSpawmed)
        {
            float h1 = Random.Range(1f, 2f);
            RBOV.y += (SPOV + h1);
            RLBOV.y = RBOV.y;
            RB.transform.position = RBOV;
            RlB.transform.position = RLBOV;
            int rD = Random.Range(1, 3);
            if (rD > 1)
            {
                spawmRbr();
            }
            else if (rD < 2)
            {
                spawmRleaveBr();
            }
        }
    }
    void spawmRoundBr()
    {
        Vector3 RBUD = RRoundBr.transform.position;
        Vector3 LBUD = LRoundBr.transform.position;
        if (RightSpawmed)
        {
            RBUD.y = RlB.transform.position.y - 1.25f;
            RRoundBr.transform.position = RBUD;
            spawmRRoundBr();
        }
        else if (LeftSpawmed)
        {
            LBUD.y = LlB.transform.position.y - 1.25f;
            LRoundBr.transform.position = LBUD;
            spawmLRoundBr();
        }
    }
    void spawmLRoundBr()
    {
        Instantiate(roundLbranch, LRoundBr.position, LRoundBr.rotation);
    }
    void spawmRRoundBr()
    {
        Instantiate(roundRbranch, RRoundBr.position, RRoundBr.rotation);
    }
}

