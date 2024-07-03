/*
 *  \author Pedro Gil Azevedo 102567
 */

#include "somm23.h"
#include <typeinfo>


namespace group 
{

// ================================================================================== //

    void feqInsert(FutureEventType type, uint32_t time, uint32_t pid)
    {
        const char *tas = type == ARRIVAL ? "ARRIVAL" : type == TERMINATE ? "TERMINATE" : "UNKOWN";
        soProbe(204, "%s(%s, %u, %u)\n", __func__, tas, time, pid);

        require(pid > 0, "process ID must be non-zero");

        /* TODO POINT: Replace next instruction with your code */
        //throw Exception(ENOSYS, __func__);
        FeqEventNode *p1 = NULL, *p2 = feqHead;
        FeqEventNode *p = new FeqEventNode;
        if(p == NULL){
        	throw Exception(errno, __func__);
        }
     	p->event.pid = pid;
        p->event.type = type;
        p->event.time = time;
        for(;p2!=NULL;p1=p2,p2=p2->next) {
        	//printf("Inside for\n");
        	if(p2->event.time < time) {
        		//printf("time less than\n");
        		continue;
        	}
        	if(p2->event.time > time) {
        		//printf("time more than\n");
        		break;
        	}
        	if((type == TERMINATE) && (p2->event.type == ARRIVAL)) {
        		//printf("time same\n");
        		break;
        	}	
        }
        /*if(p2 == NULL) {*/
	p->next = p2;
	if (p1 != NULL) {
		p1->next = p;
	} else {
		feqHead = p;
	}
        /*} else {
        	p->next = p2;
        	if (p1 != NULL) {
        		p1->next = p;
        	} else {
	        	feqHead = p;
        	}
        }*/
        //printf("Insert DONE!\n");
    }

// ================================================================================== //

} // end of namespace group

