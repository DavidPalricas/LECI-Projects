/*
 *  \author Pedro Gil Azevedo 102567
 */

#include "somm23.h"

#include <stdio.h>
#include <stdint.h>

namespace group 
{

// ================================================================================== //

    void feqPrint(FILE *fout)
    {
        soProbe(203, "%s(\"%p\")\n", __func__, fout);

        require(fout != NULL and fileno(fout) != -1, "fout must be a valid file stream");

        /* TODO POINT: Replace next instruction with your code */
        //sthrow Exception(ENOSYS, __func__);
        printf("+==============================+\n");//+==============================+
        printf("|      Future Event Queue      |\n");//|      Future Event Queue      |
        printf("+----------+-----------+-------+\n");//+----------+-----------+-------+
        printf("|   time   |   type    |  PID  |\n");//|   time   |   type    |  PID  |
        printf("+----------+-----------+-------+\n");//+----------+-----------+-------+
	FeqEventNode *p2 = feqHead;
	for(;p2!=NULL;p2=p2->next) {
		const char *tas = p2->event.type == ARRIVAL ? "ARRIVAL" : p2->event.type == TERMINATE ? "TERMINATE" : "UNKOWN";
        	printf("|%9d | %-9s | %5d |\n",p2->event.time,tas,p2->event.pid);
        }
        printf("+==============================+\n");
        printf("\n");
                
    }

// ================================================================================== //

} // end of namespace group


/*
+==============================+
|      Future Event Queue      |
+----------+-----------+-------+
|   time   |   type    |  PID  |
+----------+-----------+-------+
|        0 | TERMINATE |  1001 |
|        0 |   ARRIVAL |   111 |
|        0 |   ARRIVAL |  1002 |
|      100 | TERMINATE |  9999 |
|      100 |   ARRIVAL |   222 |
|      100 |   ARRIVAL |   333 |
|      101 | TERMINATE |  1003 |
|     1000 | TERMINATE |  8888 |
+==============================+
+==============================+
|      Future Event Queue      |
+----------+-----------+-------+
|   time   |   type    |  PID  |
+----------+-----------+-------+
|        0 |   ARRIVAL |   111 |
|        0 |   ARRIVAL |  1002 |
|      100 | TERMINATE |  9999 |
|      100 |   ARRIVAL |   222 |
|      100 |   ARRIVAL |   333 |
|      101 | TERMINATE |  1003 |
|     1000 | TERMINATE |  8888 |
+==============================+

+==============================+
|      Future Event Queue      |
+----------+-----------+-------+
|   time   |   type    |  PID  |
+----------+-----------+-------+
|        0 | TERMINATE |  1001 |
|        0 | ARRIVAL   |   111 |
|        0 | ARRIVAL   |  1002 |
|      100 | TERMINATE |  9999 |
|      100 | ARRIVAL   |   222 |
|      100 | ARRIVAL   |   333 |
|      101 | TERMINATE |  1003 |
|     1000 | TERMINATE |  8888 |
+==============================+

+==============================+
|      Future Event Queue      |
+----------+-----------+-------+
|   time   |   type    |  PID  |
+----------+-----------+-------+
|        0 | ARRIVAL   |   111 |
|        0 | ARRIVAL   |  1002 |
|      100 | TERMINATE |  9999 |
|      100 | ARRIVAL   |   222 |
|      100 | ARRIVAL   |   333 |
|      101 | TERMINATE |  1003 |
|     1000 | TERMINATE |  8888 |
+==============================+
+==============================+
|      Future Event Queue      |
+----------+-----------+-------+
|   time   |   type    |  PID  |
+----------+-----------+-------+
|        0 | TERMINATE |  1001 |
|        0 | ARRIVAL   |   111 |
|        0 | ARRIVAL   |  1002 |
|      100 | TERMINATE |  9999 |
|      100 | ARRIVAL   |   222 |
|      100 | ARRIVAL   |   333 |
|      101 | TERMINATE |  1003 |
|     1000 | TERMINATE |  8888 |
+==============================+

*/

