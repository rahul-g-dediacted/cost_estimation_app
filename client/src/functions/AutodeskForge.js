import socketIOClient from "socket.io-client";
export const socket = window.location.origin.includes('http://localhost:3000') ? socketIOClient(window.location.origin) :
 socketIOClient(window.location.origin)

export const getForgeToken=(callback) =>{
    // get forge token
    fetch('/api/forge/oauth/token').then(res => {
      res.json().then(data => {
        callback(data.access_token, data.expires_in);
      });
    });
  }

  export const  getLeafNodes= (model, dbIds) =>{
    return new Promise((resolve, reject) => {
      try {
        const instanceTree =
          model.getData().instanceTree ||
          model.getFragmentMap()

        dbIds = dbIds || instanceTree.getRootId()

        const dbIdArray = Array.isArray(dbIds)
          ? dbIds
          : [dbIds]

        const leafIds = []

        const getLeafNodeIdsRec = (id) => {
          let childCount = 0

          instanceTree.enumNodeChildren(id, (childId) => {
            getLeafNodeIdsRec(childId)
            ++childCount
          })

          if (childCount === 0) {
            leafIds.push(id)
          }
        }

        dbIdArray.forEach((dbId) => {
          getLeafNodeIdsRec(dbId)
        })

        return resolve(leafIds)
      } catch (ex) {
        return reject(ex)
      }
    })
  }

  export const getBulkPropertiesAsync =(model, dbIds, propFilter) =>{
    return new Promise(async (resolve, reject) => {
      if (typeof propFilter === 'function') {
        const propTasks = dbIds.map((dbId) => {
          return this.getProperty(
            model, dbId, propFilter, 'Not Found')
        })

        const propRes = await Promise.all(propTasks)

        const filteredRes = propRes.filter((res) => {
          return res.displayValue !== 'Not Found'
        })

        resolve(filteredRes.map((res) => {
          return {
            properties: [res],
            dbId: res.dbId
          }
        }))
      } else {
        const propFilterArray = Array.isArray(propFilter)
          ? propFilter : [propFilter]

        model.getBulkProperties(dbIds, propFilterArray, (result) => {
          resolve(result)
        }, (error) => {
          console.log(error)
          reject(error)
        })
      }
    })
  }

  export const  getAllElementsInView = (viewer3D) => {
    const instanceTree = viewer3D.model.getData().instanceTree;
    //console.log(instanceTree);
    const rootId = instanceTree.getRootId();
    let alldbId = [];
    if (!rootId) {
      return [{ model: viewer3D.model, selection: alldbId }];
    }
    let queue = [];
    queue.push(rootId);
    while (queue.length > 0) {
      var node = queue.shift();
      if (node !== rootId) alldbId = [...alldbId, node];
      instanceTree.enumNodeChildren(node, function (childrenIds) {
        queue.push(childrenIds);
      });
    }

    const allElements = [{ model: viewer3D.model, selection: alldbId }];
    return allElements;
  };

  export function getAllElementdbIdsOneModel(viewer) {
    try {
       var instanceTree = viewer.impl.model.getData().instanceTree;
       var temp = [];
       if (!instanceTree) {
          return temp;
       }
       var queue = [];
       queue.push(instanceTree.getRootId());
       while (queue.length > 0) {
          var node = queue.shift();
          if (instanceTree.getChildCount(node) !== 0) {
            //temp.push(node);
            instanceTree.enumNodeChildren(node, function (childrenIds) {
                queue.push(childrenIds);
             });
          }
          else {
             temp.push(node);
          }
       }
       return temp;
    } catch { }
 
 }

 export function sortChildrenCount(a, b) {

  if (a.children.length < b.children.length) {
      return 1;
  }
  if (a.children.length > b.children.length) {
      return -1;
  }
  return 0;
}

